$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');

        this.get('#/home', getWelcomePage);
        this.get('index.html', getWelcomePage);

        this.post('#/register', (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPass = ctx.params.repeatPass;

            if (!/^[A-Za-z]{3,}$/.test(username)) {
                notify.showError('Username should be at least 3 characters long and contain only english alphabet letters');
            } else if (!/^[A-Za-z\d]{6,}$/.test(password)) {
                notify.showError('Password should be at least 6 characters long and contain only english alphabet letters');
            } else if (repeatPass !== password) {
                notify.showError('Passwords must match!');
            } else {
                auth.register(username, password)
                    .then((userData) => {
                        auth.saveSession(userData);
                        notify.showInfo('User registration successful!');
                        ctx.redirect('#/catalog');
                    })
                    .catch(notify.handleError);
            }
        });
        this.post('#/login', (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;

            if (username === '' || password === '') {
                notify.showError('All fields should be non-empty!');
            } else {
                auth.login(username, password)
                    .then((userData) => {
                        auth.saveSession(userData);
                        notify.showInfo('Login successful.');
                        ctx.redirect('#/catalog');
                    })
                    .catch(notify.handleError);
            }
        });
        this.get('#/logout', (ctx) => {
            auth.logout()
                .then(() => {
                    sessionStorage.clear();
                    ctx.redirect('#/home');
                })
                .catch(notify.handleError);
        });

        this.get('#/catalog', (ctx) => {
            if (!auth.isAuth()) {
                ctx.redirect('#/home');
                return;
            }

            posts.getAllPosts()
                .then((posts) => {
                    posts.forEach((p, i) => {
                        p.rank = i + 1;
                        p.date = calcTime(p._kmd.ect);
                        p.isAuthor = p._acl.creator === sessionStorage.getItem('userId');
                    });

                    ctx.isAuth = auth.isAuth();
                    ctx.username = sessionStorage.getItem('username');
                    ctx.posts = posts;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        postList: './templates/posts/postList.hbs',
                        post: './templates/posts/post.hbs'
                    }).then(function () {
                        this.partial('./templates/posts/catalogPage.hbs');
                    })
                })
                .catch(notify.handleError);
        });

        this.get('#/create/post', (ctx) => {
            if (!auth.isAuth) {
                ctx.redirect('#/home');
                return;
            }else{
                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    navigation: './templates/common/navigation.hbs'
                }).then(function (){
                    this.partial('/templates/posts/createPostPage.hbs');
                });
            }
        });
        this.post('#/create/post', (ctx) => {
            if (!auth.isAuth) {
                ctx.redirect('#/home');
                return;
            }
            let url = ctx.params.url;
            let title = ctx.params.title;
            let imageUrl = ctx.params.imageUrl;
            let description = ctx.params.description;
            let author = sessionStorage.getItem('username');

            if (url === '' || !url.startsWith('http')) {
                notify.showError('Url cannot be empty and must starts with "http"!');
            }else if(title === ''){
                notify.showError('Title cannot be empty!');
            }else {
                posts.createPost(author, title, description, url, imageUrl)
                    .then(() => {
                        notify.showInfo('Post was created successful!');
                        ctx.redirect('#/catalog');
                    }).catch(notify.handleError);
            }
        });

        this.get('#/edit/post/:postId', (ctx) => {
            if (!auth.isAuth()) {
                ctx.redirect('#/home');
                return;
            }
            let postId = ctx.params.postId;

            posts.getPostById(postId)
                .then((post) => {
                    ctx.isAuth = auth.isAuth();
                    ctx.username = sessionStorage.getItem('username');
                    ctx.post = post;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                    }).then(function () {
                        this.partial('./templates/posts/editPostPage.hbs');
                    });
                });
        });
        this.post('#/edit/post', (ctx) => {
            if (!auth.isAuth) {
                ctx.redirect('#/home');
                return;
            }
            let postId = ctx.params.postId;
            let url = ctx.params.url;
            let title = ctx.params.title;
            let imageUrl = ctx.params.imageUrl;
            let description = ctx.params.description;
            let author = sessionStorage.getItem('username');

            if (url === '' || !url.startsWith('http')) {
                notify.showError('Url cannot be empty and must starts with "http"!');
            }else if(title === ''){
                notify.showError('Title cannot be empty!');
            }else {
                posts.editPost(postId, author, title, description, url, imageUrl)
                    .then(() => {
                        notify.showInfo(`${title} was updated successful!`);
                        ctx.redirect('#/catalog');
                    }).catch(notify.handleError);
            }
        });
        
        this.get('#/delete/post/:postId', (ctx)=>{
            if (!auth.isAuth) {
                ctx.redirect('#/home');
                return;
            }
            let postId = ctx.params.postId;

            posts.deletePost(postId)
                .then(() => {
                    notify.showInfo('Post deleted.');
                    ctx.redirect('#/catalog');
                })
                .catch(notify.handleError);
        });
        this.get('#/posts', (ctx) => {
            if (!auth.isAuth()) {
                ctx.redirect('#/home');
                return;
            }

            posts.getMyPosts(sessionStorage.getItem('username'))
                .then((posts) => {
                    posts.forEach((p, i) => {
                        p.rank = i + 1;
                        p.date = calcTime(p._kmd.ect);
                        p.isAuthor = p._acl.creator === sessionStorage.getItem('userId');
                    });

                    ctx.isAuth = auth.isAuth();
                    ctx.username = sessionStorage.getItem('username');
                    ctx.posts = posts;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        postList: './templates/posts/postList.hbs',
                        post: './templates/posts/post.hbs'
                    }).then(function () {
                        this.partial('./templates/posts/myPostsPage.hbs');
                    });
                })
        });

        this.get('#/details/:postId', (ctx) => {
            let postId = ctx.params.postId;

            const postPromise = posts.getPostById(postId);
            const allCommentsPromise = comments.getPostComments(postId);

            Promise.all([postPromise, allCommentsPromise])
                .then(([post, comments]) => {
                    post.date = calcTime(post._kmd.ect);
                    post.isAuthor = post._acl.creator === sessionStorage.getItem('userId');
                    comments.forEach((c) => {
                        c.date = calcTime(c._kmd.ect);
                        c.commentAuthor = c._acl.creator === sessionStorage.getItem('userId');
                    });

                    ctx.isAuth = auth.isAuth();
                    ctx.username = sessionStorage.getItem('username');
                    ctx.post = post;
                    ctx.comments = comments;

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        navigation: './templates/common/navigation.hbs',
                        postDetails: './templates/details/postDetails.hbs',
                        comment: './templates/details/comment.hbs'
                    }).then(function () {
                        this.partial('./templates/details/postDetailsPage.hbs');
                    })
                })
                .catch(notify.handleError);
        });
        this.post('#/create/comment', (ctx) => {
            let author = sessionStorage.getItem('username');
            let content = ctx.params.content;
            let postId = ctx.params.postId;

            if (content === '') {
                notify.showError('Cannot add empty comment!');
                return;
            }

            comments.createComment(postId, content, author)
                .then(() => {
                    notify.showInfo('Comment created!');
                    ctx.redirect(`#/details/${postId}`);
                })
                .catch(notify.showError);
        });

        this.get('#/comment/delete/:commentId/post/:postId', (ctx) => {
            let commentId = ctx.params.commentId;
            let postId = ctx.params.postId;

            comments.deleteComment(commentId)
                .then(() => {
                    notify.showInfo('Comment deleted.');
                    ctx.redirect(`#/details/${postId}`);
                })
                .catch(notify.handleError);
        });
        function getWelcomePage(ctx) {
            if (!auth.isAuth()) {
                ctx.loadPartials({
                    header: './templates/common/header.hbs',
                    footer: './templates/common/footer.hbs',
                    loginForm: './templates/forms/loginForm.hbs',
                    registerForm: './templates/forms/registerForm.hbs',
                }).then(function () {
                    this.partial('./templates/welcome-anonymous.hbs');
                });
            } else {
                ctx.redirect('#/catalog');
            }

        }
        function calcTime(dateIsoFormat) {
            let diff = new Date() - (new Date(dateIsoFormat));
            diff = Math.floor(diff / 60000);
            if (diff < 1) return 'less than a minute';
            if (diff < 60) return diff + ' minute' + pluralize(diff);
            diff = Math.floor(diff / 60);
            if (diff < 24) return diff + ' hour' + pluralize(diff);
            diff = Math.floor(diff / 24);
            if (diff < 30) return diff + ' day' + pluralize(diff);
            diff = Math.floor(diff / 30);
            if (diff < 12) return diff + ' month' + pluralize(diff);
            diff = Math.floor(diff / 12);
            return diff + ' year' + pluralize(diff);
            function pluralize(value) {
                if (value !== 1) return 's';
                else return '';
            }
        }
    });

    app.run();
});
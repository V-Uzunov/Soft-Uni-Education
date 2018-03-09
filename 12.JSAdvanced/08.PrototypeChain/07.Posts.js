let result = function solve() {
    class Post{
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.commentsArray = [];
        }
        addComment(comment) {
            this.commentsArray.push(comment);
        }
        toString() {
            let result = super.toString();
            result += `\nRating: ${this.likes - this.dislikes}`;
            if (this.commentsArray.length > 0) {
                result +=`\nComments:`;
                for (const comm of this.commentsArray) {
                    result += `\n * ${comm}`;
                }
            }
            return result;
        }
    }

    class BlogPost extends Post{
        constructor (title, content, views) {
            super(title, content);
            this.views = Number(views);
        }
        view(){
            this.views ++;
            // Returns the object for chaining
            return this;
        }

        toString(){
            let base = `${super.toString()}\nViews: ${this.views}`;

            return base;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
};
let Post = result();
let SocialMediaPost = result();

let post = new Post('Post', 'Content');

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new SocialMediaPost('TestTitle', 'TestContent', 25, 30);

scm.addComment('Good post');
scm.addComment('Very good post');
scm.addComment('Wow!');

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

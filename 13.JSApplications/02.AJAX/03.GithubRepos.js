function loadRepos() {
    let username = $('#username').val();
    let uls = $('#repos');
    uls.empty();
    let req ={
        url:`https://api.github.com/users/${username}/repos`,
        success:displayRepos,
        error:displayErrors
    };
    $.ajax(req);

    function displayRepos(repos) {
        for (let repo of repos) {
            let link = $('<a>').text(repo.full_name);
            link.attr('href', repo.html_url);
            $('#repos').append($('<li>').append(link));
          }
        
    }
    function displayErrors(msg) {
        uls.append('<li>').text('Error');
    }
}
function loadCommits() {
    let githubUsername = $('#username').val();
    let githubRepo = $('#repo').val();
    let list = $('#commits');
    list.empty();
    let req = {
        url: `https://api.github.com/repos/${githubUsername}/${githubRepo}/commits`,
        success: displayCommits,
        error: handleError
    };
    $.ajax(req);

    function displayCommits(data) {
        for (const com of data) {
            let commits = $(`<li>${com.commit.author.name}: ${com.commit.message}</li>`);
            list.append(commits);
        }
    }

    function handleError(msg) {
        $('#commits').append(`<li>Error: ${msg.status} (${msg.statusText})`);
    }
}
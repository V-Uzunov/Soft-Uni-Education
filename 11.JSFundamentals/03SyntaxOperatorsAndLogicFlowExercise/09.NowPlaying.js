function nowPlaying(params) {
    let trackName = params[0];
    let artistName = params[1];
    let duration = params[2];

    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

nowPlaying(['Number One', 'Nelly', '4:09']);
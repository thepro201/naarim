function createPlayerCards(playerList) {
    const container = document.getElementById('players-container');
    container.innerHTML = "";

    playerList.forEach(player => {
        const card = document.createElement('a');
        card.className = 'player-card';
        card.href = `player-card.aspx?id=${encodeURIComponent(player.name)}`;
        card.innerHTML = `
            <div class="player-header">
                <img src="../Images/${player.image}" width="150" height="150">
                <div class="player-info">
                    <h2>${player.name}</h2>
                    <h2>${player.number}</h2>
                    <div class="player-team">${player.team} - ${player.position}</div>
                </div>
            </div>
            <div class="player-stats">
                <div class="stat">
                    <div class="stat-value">${player.PPG}</div>
                    <div class="stat-label">PPG</div>
                </div>
                <div class="stat">
                    <div class="stat-value">${player.APG}</div>
                    <div class="stat-label">APG</div>
                </div>
                <div class="stat">
                    <div class="stat-value">${player.RPG}</div>
                    <div class="stat-label">RPG</div>
                </div>
            </div>
        `;
        container.appendChild(card);
    });
}

function populateTeamFilter() {
    const filter = document.getElementById('team-filter');
    const teams = [...new Set(players.map(p => p.team))];
    teams.forEach(team => {
        const option = document.createElement('option');
        option.value = team;
        option.textContent = team;
        filter.appendChild(option);
    });
}

function filterPlayers() {
    const team = document.getElementById('team-filter').value;
    const position = document.getElementById('position-filter').value;

    const filtered = players.filter(p =>
        (team === "all" || p.team === team) &&
        (position === "all" || p.position === position)
    );

    createPlayerCards(filtered);
}

populateTeamFilter();
filterPlayers();

document.getElementById('team-filter').addEventListener('change', filterPlayers);
document.getElementById('position-filter').addEventListener('change', filterPlayers);

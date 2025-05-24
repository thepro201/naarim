document.addEventListener('DOMContentLoaded', () => {
    const teamFilter = document.getElementById('team-filter');
    const monthFilter = document.getElementById('month-filter');
    const roundFilter = document.getElementById('round-filter');

    teamFilter.addEventListener('change', filterGames);
    monthFilter.addEventListener('change', filterGames);
    roundFilter.addEventListener('change', filterGames);

    displaySchedule(games);
});

function filterGames() {
    const teamValue = document.getElementById('team-filter').value;
    const monthValue = document.getElementById('month-filter').value;
    const roundValue = document.getElementById('round-filter').value;

    let filtered = [...games];

    if (teamValue !== 'all') {
        filtered = filtered.filter(
            g => g.HomeTeam.TeamName === teamValue || g.AwayTeam.TeamName === teamValue
        );
    }

    if (monthValue !== 'all') {
        filtered = filtered.filter(g => {
            const date = new Date(g.Date);
            const monthName = date.toLocaleString('en-US', { month: 'long' });
            return monthName === monthValue;
        });
    }

    if (roundValue !== 'all') {
        const roundNumber = parseInt(roundValue.replace("Round ", ""));
        const gamesPerRound = teams.length / 2;
        const startIndex = (roundNumber - 1) * gamesPerRound;
        filtered = games.slice(startIndex, startIndex + gamesPerRound).filter(g =>
            teamValue === 'all' || g.HomeTeam.TeamName === teamValue || g.AwayTeam.TeamName === teamValue
        );
    }

    displaySchedule(filtered);
}

function displaySchedule(filteredGames) {
    const container = document.getElementById('schedule-container');
    container.innerHTML = '';

    const groupedGames = filteredGames.reduce((acc, game) => {
        const date = new Date(game.Date);
        const month = date.toLocaleString('he-IL', { month: 'long', year: 'numeric' });
        if (!acc[month]) acc[month] = [];
        acc[month].push(game);
        return acc;
    }, {});

    Object.entries(groupedGames).forEach(([month, gamesInMonth]) => {
        const monthSection = document.createElement('div');
        monthSection.className = 'month-section';
        monthSection.innerHTML = `<h2 class="month-title">${month}</h2>`;

        gamesInMonth.forEach(game => {
            const dateObj = new Date(game.Date);
            if (isNaN(dateObj)) return;

            const formattedDate = {
                day: dateObj.getDate(),
                month: dateObj.toLocaleString('he-IL', { month: 'short' }),
                weekday: dateObj.toLocaleString('he-IL', { weekday: 'short' })
            };

            const timeString = dateObj.toTimeString().slice(0, 5);

            const homeTeam = teams.find(t => t.TeamName === game.HomeTeam.TeamName);
            const awayTeam = teams.find(t => t.TeamName === game.AwayTeam.TeamName);

            if (!homeTeam || !awayTeam) return;

            const gameCard = document.createElement('div');
            gameCard.addEventListener('click', () => {
                const url = `game.aspx?date=${encodeURIComponent(game.Date)}&time=${encodeURIComponent(timeString)}&home=${encodeURIComponent(homeTeam.TeamName)}&homeImg=${encodeURIComponent(homeTeam.Icon)}&away=${encodeURIComponent(awayTeam.TeamName)}&awayImg=${encodeURIComponent(awayTeam.Icon)}&venue=${encodeURIComponent(homeTeam.City)}`;
                window.location.href = url;
            });

            gameCard.className = 'game-card';
            gameCard.innerHTML = `
                <div class="game-date">
                    <div class="game-day">${formattedDate.day}</div>
                    <div class="game-time">${formattedDate.weekday} ${timeString}</div>
                </div>
                <div class="game-teams">
                    <div class="team">
                        <img src="../Images/${homeTeam.Icon}.png" width="50" height="50" />
                        <span>${game.HomeTeam.TeamName}</span>
                    </div>
                    <span class="versus">vs</span>
                    <div class="team">
                        <img src="../Images/${awayTeam.Icon}.png" width="50" height="50" />
                        <span>${game.AwayTeam.TeamName}</span>
                    </div>
                </div>
                <div class="game-venue">${game.Venue}</div>
            `;
            monthSection.appendChild(gameCard);
        });

        container.appendChild(monthSection);
    });

    if (filteredGames.length === 0) {
        container.innerHTML = `<p class="no-games">לא נמצאו משחקים מתאימים</p>`;
    }
}

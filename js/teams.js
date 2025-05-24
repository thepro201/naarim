
function createTeamCards() {
  const container = document.getElementById('teams-container');
  
    teams.forEach(team => {
        const card = document.createElement('a');  // משנים div ל-a
        card.className = 'team-card';
        card.href = `team.aspx?id=${encodeURIComponent(team.name)}`; // מקשרים לדף השחקן עם הפרמטר id
    card.innerHTML = `
    <img src="../Images/${team.icon}.png"width="200" height="200">
    <h2 class="team-name">${team.name}</h2>
    <p>${team.city}</p>
    <p>מאמן: ${team.coach}</p>
    <div class="team-stats">
        <div class="stat">
            <div class="stat-value">${team.played}</div>
            <div class="stat-label">משחקים</div>
        </div>
        <div class="stat">
            <div class="stat-value">${team.won}</div>
            <div class="stat-label">נצחונות</div>
        </div>
        <div class="stat">
            <div class="stat-value">${((team.won / team.played) * 100).toFixed(1)}%</div>
            <div class="stat-label">% נצחונות</div>
        </div>
    </div>
    `;
      const pageNameWithoutExtension = window.location.pathname.split('/').pop().split('.')[0];
      if (pageNameWithoutExtension == "teams")
        container.appendChild(card);
      
  });
}

    createTeamCards();
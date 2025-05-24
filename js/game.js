
function getQueryParams() {
    const params = new URLSearchParams(window.location.search);
    return {
        date: params.get('date'),
        time: params.get('time'),
        homeTeam: params.get('home'),
        homeImg: params.get('homeImg'),
        awayTeam: params.get('away'),
        awayImg: params.get('awayImg'),
        venue: params.get('venue')
    };
}

function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString('he-IL', {
        weekday: 'long',
        year: 'numeric',
        month: 'long',
        day: 'numeric'
    });
}

function initialize() {
    const params = getQueryParams();

    document.getElementById('home-team').textContent = params.homeTeam;
    document.getElementById('away-team').textContent = params.awayTeam;
    document.getElementById('home-logo').innerHTML = `
  <a href="team.aspx?id=${encodeURIComponent(params.homeTeam)}">
    <img src="../Images/${params.homeImg}.png" width="75" height="75" style="cursor:pointer;">
  </a>`;

    document.getElementById('away-logo').innerHTML = `
  <a href="team.aspx?id=${encodeURIComponent(params.awayTeam)}">
    <img src="../Images/${params.awayImg}.png" width="75" height="75" style="cursor:pointer;">
  </a>`;


    document.getElementById('game-status').innerHTML =
        `${formatDate(params.date)}<br>${params.time}`;

    document.getElementById('venue').textContent = params.venue;

    document.getElementById('map').innerHTML = `
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3385.579961992175!2d34.8369813238887!3d31.94515942603142!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1502b5c4aec13da7%3A0xef46b4c418c93566!2z15TXqteQ16DXlCAxLCDXkdeQ16gg15nXoten15EsIDcwMzA2NTk!5e0!3m2!1siw!2sil!4v1748093886696!5m2!1siw!2sil" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>`;
}

initialize();
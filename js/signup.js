
document.getElementById('signupForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const birth = document.getElementById('birth').value;
    const boy = document.getElementById('boy').value;
    const girl = document.getElementById('girl').value;
    const tz = document.getElementById('tz').value;


    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$/;
    if (!passwordRegex.test(password)) {
        divPassError.innerHTML = "הסיסמה לא מתאימה לתנאים";
        return;
    }
    if (password !== confirmPassword) {
        divPassError.innerHTML = "הסיסמאות לא שוות";
        return;
    }

    const hebrewRegex = /^[\u0590-\u05FF\s]+$/;
    if (!hebrewRegex.test(firstName)) {
        divPassError.innerHTML = "השם הפרטי חייב להכיל אותיות בעברית בלבד";
        return;
    }
    if (!hebrewRegex.test(lastName)) {
        divPassError.innerHTML = "השם משפחה חייב להכיל אותיות בעברית בלבד";
        return;
    }
    divPassError.innerHTML = "";
    console.log('Registration attempt:', { firstName, lastName, email, password });

    alert('Registration successful! (This is a demo)');
});

document.getElementById('player').addEventListener('change', function () {
    const showtz = document.getElementById('showtz');
    if (this.checked) {
        showtz.style.display = 'block';
    } else {
        showtz.style.display = 'none';
    }
});
function limitTzLength(input) {
    input.value = input.value.replace(/\D/g, '').substring(0, 9);
}

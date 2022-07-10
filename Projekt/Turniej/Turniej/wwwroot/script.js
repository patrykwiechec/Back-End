var max_czas_sesji = 15;
var _bezczynnosc = 0;
document.onclick = function () {_bezczynnoscLicznik
    _bezczynnosc = 0;
};
document.onmousemove = function () {
    _bezczynnosc = 0;
};
document.onkeypress = function () {
    _bezczynnosc = 0;
};
window.setInterval(CheckIdleTime, 1000);

function CheckIdleTime() {
    _bezczynnosc++;
    if ((max_czas_sesji - _bezczynnosc)>=10)
        document.getElementById('time').innerHTML = "00:" + (max_czas_sesji - _bezczynnosc);
    else
        document.getElementById('time').innerHTML = "00:0" + (max_czas_sesji - _bezczynnosc);
    if (_bezczynnosc >= max_czas_sesji) {
        alert("Zbyt długo byłeś nieaktywny! Powrót na stronę główną.");
        location.href = "http://localhost:5225/";
    }
}
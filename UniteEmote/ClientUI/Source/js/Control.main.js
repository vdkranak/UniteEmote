function sendEmote1() {
    var n = JSON.stringify({}),
        t = btoa(n),
        i = {
            DataType: 301,
            Base64Data: t,
            Priority: 2
        };
    window.IntelUnite.sendMessage(i)
}
function sendEmote2() {
    var n = JSON.stringify({}),
        t = btoa(n),
        i = {
            DataType: 302,
            Base64Data: t,
            Priority: 2
        };
    window.IntelUnite.sendMessage(i)
}
function sendEmote3() {
    var n = JSON.stringify({}),
        t = btoa(n),
        i = {
            DataType: 303,
            Base64Data: t,
            Priority: 2
        };
    window.IntelUnite.sendMessage(i)
}
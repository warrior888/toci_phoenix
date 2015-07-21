

function PobierzInformacje() {

    $.ajax(
        {
            url: 'random.txt',
            success: function (data) {

                document.getElementById('bazowy').innerHTML = data;
            }
        }
    );
}
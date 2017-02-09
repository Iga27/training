
var message = function (senderid,recipientid,text,name) {
    this.senderid = senderid;
    this.recipientid = recipientid;
    this.text = text;
    this.name = name;
}


var viewModel = {
    messages: ko.observableArray([]),
 
     
    writeMessage: function () {
        var text = $('#message').val();
        if (text.length > 0) {
            var newmessage = {
                SenderId : $('#currentUserId').val(),
                RecipientId : $('#recipient').val(),
                Text: $('#message').val(),
 
            };

            $.ajax({
                url: '/api/messagesapi/',
                type: 'POST',
                data: JSON.stringify(newmessage),
                contentType: "application/json;charset=utf-8",
                success: function () {
                    $('#message').val('');
                }
            });
        }
    }
}

 
ko.applyBindings(viewModel);


 


$(function () {
    var hub = $.connection.messagesHub;
    $.connection.hub.start();
    

     
    hub.client.addedNewMessage = function (senderId,recipientId,text,name) {
        var newMessage = new message(senderId,recipientId,text,name);
         
        viewModel.messages.unshift(newMessage);

    };
 
});
'use strict';

const messagesContainer = document.getElementById('messages');
const connection = new signalR.HubConnectionBuilder()
    .withUrl('/chat/hub')
    .build();
const formElement = document.getElementById('message-form');

// Receiving messages

connection.on('OnMessageSent', (user, message) => {
    const messageElement = document.createElement('div');
    messageElement.className = 'p-2';
    messageElement.innerText = user + ": " + message;
    messagesContainer.appendChild(messageElement);
    messagesContainer.scrollTo(0, messagesContainer.scrollHeight);
});


// Connection

function startConnection() {
    connection.start().catch(() => setTimeout(startConnection, 1000)); // retry starting connection
}

connection.onclose(() => startConnection()); // reconnect if lost
startConnection();

// Sending messages

formElement.addEventListener('submit', (event) => {
    const message = formElement.elements.message.value;
    event.preventDefault(); // stopping site refresh

    if (message) {
        connection.invoke('SendMessage', message);
    }
    formElement.elements.message.value = '';
});

﻿// ----------------------------------------------------------------------------------------------------------------------
// <summary>The Photon Chat Api enables clients to connect to a chat server and communicate with other clients.</summary>
// <remarks>ChatClient is the main class of this api.</remarks>
// <copyright company="Exit Games GmbH">Photon Chat Api - Copyright (C) 2014 Exit Games GmbH</copyright>
// ----------------------------------------------------------------------------------------------------------------------

namespace ExitGames.Client.Photon.Chat
{
    /// <summary>
    /// Callback interface for Chat client side. Contains callback methods to notify your app about updates.
    /// Must be provided to new ChatClient in constructor
    /// </summary>
    public interface IChatClientListener
    {
        /// <summary>
        /// Disconnection happened.
        /// </summary>
        void OnDisconnected();

        /// <summary>
        /// Client is connected now.
        /// </summary>
        /// <remarks>
        /// Clients have to be connected before they can send their state, subscribe to channels and send any messages.
        /// </remarks>
        void OnConnected();

        /// <summary>The ChatClient's state changed. Usually, OnConnected and OnDisconnected are the callbacks to react to.</summary>
        /// <param name="state">The new state.</param>
        void OnChatStateChange(ChatState state);

        /// <summary>
        /// Notifies app that client got new messages from server
        /// Number of senders is equal to number of messages in 'messages'. Sender with number '0' corresponds to message with
        /// number '0', sender with number '1' corresponds to message with number '1' and so on
        /// </summary>
        /// <param name="channelName">channel from where messages came</param>
        /// <param name="senders">list of users who sent messages</param>
        /// <param name="messages">list of messages it self</param>
        void OnGetMessages(string channelName, string[] senders, object[] messages);

        /// <summary>
        /// Notifies client about private message
        /// </summary>
        /// <param name="sender">user who sent this message</param>
        /// <param name="message">message it self</param>
        /// <param name="channelName">channelName for private messages (messages you sent yourself get added to a channel per target username)</param>
        void OnPrivateMessage(string sender, object message, string channelName);

        /// <summary>
        /// Result of Subscribe operation. Returns per channelname if the channel is now subscribed.
        /// </summary>
        /// <param name="channels">Array of channel names.</param>
        /// <param name="results">Per channel result if subscribed.</param>
        void OnSubscribed(string[] channels, bool[] results);

        /// <summary>
        /// Result of Unsubscribe operation. Returns per channelname if the channel is now unsubscribed.
        /// </summary>
        /// <param name="channels">Array of channel names that are no longer subscribed.</param>
        void OnUnsubscribed(string[] channels);

        /// <summary>
        /// New status of another user (you get updates for users set in your friends list).
        /// </summary>
        /// <param name="user">Name of the user.</param>
        /// <param name="status">New status of that user.</param>
        /// <param name="gotMessage">True if the status contains a message you should cache locally. False: This status update does not include a message (keep any you have).</param>
        /// <param name="message">Message that user set.</param>
        void OnStatusUpdate(string user, int status, bool gotMessage, object message);
    }
}
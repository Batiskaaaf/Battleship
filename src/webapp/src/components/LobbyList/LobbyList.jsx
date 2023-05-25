import React from 'react';
import Lobby from '../Lobby/Lobby';
import styles from './LobbyList.module.css';

const LobbyList = () => {
  const lobbies = [
    { id: 1, name: 'Lobby 1' },
    { id: 2, name: 'Lobby 2' },
    { id: 2, name: 'Lobby 2' },
    { id: 2, name: 'Lobby 2' },
    { id: 2, name: 'Lobby 2' },
    { id: 2, name: 'Lobby 2' },
    { id: 2, name: 'Lobby 2' },
    { id: 3, name: 'Lobby 3' }
  ];

  const handleJoin = (lobbyId) => {
    console.log(`Joining lobby with ID ${lobbyId}`);
    // Add your logic for joining the lobby here
  };

  return (
    <div className={styles.lobbyList}>
      <h1 className={styles.lobbyListTitle}>Lobby List</h1>
      <div className={styles.lobbylist__lobbiescontainer}>
        {lobbies.map(lobby => (
          <Lobby key={lobby.id} lobby={lobby} onJoin={handleJoin} />
        ))}
      </div>
    </div>
  );
};

export default LobbyList;
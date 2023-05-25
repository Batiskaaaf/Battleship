import React from 'react';
import styles from './Lobby.module.css'

const Lobby = ({ lobby, onJoin }) => {
  const handleJoinClick = () => {
    onJoin(lobby.id);
  };

  return (
    <div className={styles.lobbyContainer}>
      <h3 className={styles.lobbyName}>{lobby.name}</h3>
      <button className={styles.joinButton} onClick={handleJoinClick}>Join</button>
    </div>
  );
};

export default Lobby;
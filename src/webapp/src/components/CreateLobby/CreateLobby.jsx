import React, { useState } from 'react';
import styles from './CreateLobby.module.css';

const CreateLobby = ({ onCreateLobby }) => {
  const [lobbyName, setLobbyName] = useState('');
  const [isPrivate, setIsPrivate] = useState(false);

  const handleLobbyNameChange = (e) => {
    setLobbyName(e.target.value);
  };

  const handleIsPrivateChange = (e) => {
    setIsPrivate(e.target.checked);
  };

  const handleCreateLobbySubmit = () => {
    onCreateLobby(lobbyName, isPrivate);

    // Reset the input values
    setLobbyName('');
    setIsPrivate(false);
  };

  return (
    <div className={styles.createLobbyContainer}>
      <h2>Create Lobby</h2>
      <input
        type="text"
        placeholder="Lobby Name"
        value={lobbyName}
        onChange={handleLobbyNameChange}
        className={styles.input}
      />
      <label className={styles.checkboxLabel}>
        <input
          type="checkbox"
          checked={isPrivate}
          onChange={handleIsPrivateChange}
          className={styles.checkbox}
        />
        Private Lobby
      </label>
      <button onClick={handleCreateLobbySubmit} className={styles.createButton}>
        Create
      </button>
    </div>
  );
};

export default CreateLobby;
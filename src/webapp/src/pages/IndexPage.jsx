import React, { useState } from "react";
import LobbyList from "../components/LobbyList/LobbyList";
import styles from './IndexPage.module.css'
import CreateLobby from "../components/CreateLobby/CreateLobby";

const Index = () =>{

    const handleCreateLobby = () =>{

    }


    return (
    <div className={styles.lobbyPageContainer}>
        <CreateLobby onCreateLobby={handleCreateLobby} />
        <LobbyList />
    </div>
    )
}; 


export default Index;
import React, { useState } from "react";
import Grid from "../components/Grid/Grid";
import ShipsLayout from "../components/ShipsLayout";

const LobbyPage = () => {

    const [shipList, setShipList] = useState([
        {id: 1, name: "submarine", color:"red", direction: "v", length: 1},
        {id: 2, name: "submarine", color:"red", direction: "v", length: 1},
        {id: 3, name: "submarine", color:"red", direction: "v", length: 1},
        {id: 4, name: "submarine", color:"red", direction: "v", length: 1},
        {id: 5, name: "patrolboat", color: "blue", direction: "v", length: 2},
        {id: 6, name: "patrolboat", color: "blue", direction: "v", length: 2},
        {id: 7, name: "patrolboat", color: "blue", direction: "v", length: 2},
        {id: 8, name: "cruiser", color: "green", direction: "v", length: 3},
        {id: 9, name: "cruiser", color: "green", direction: "v", length: 3},
        {id: 10, name: "battleship", color: "purple", direction: "v", length: 4},
    ])

    const [selectedShip, setSelectedShip] = useState(null);

    const dragStartHandler = (e,item) => {
       setSelectedShip(item);
    } 
    const dropHandler = (e,item) => {
        e.preventDefault();
    } 
    const dragEndHandler = (e) => {
    } 
    const dragOverHandler = (e) => {
        e.preventDefault();
    } 

    const setCoordinatesOfShip = (cell) =>{
        const ship = selectedShip;
        ship.cell = cell;
        setSelectedShip(ship);   
        setSelectedShip(null);
        setShipList([...shipList]);
    }

    
    return(
        <div className="lobbypage">
            <div className="lobby-row">
                    <div className="lobby-grid lobby-row-container">          
                        <div className="grid-container">          
                            <ShipsLayout shiplist={shipList} setCoorsOfShip={setCoordinatesOfShip}></ShipsLayout>
                        </div>
                        <div  className="ships">
                            {shipList.filter(ship => !ship.cell).map((ship) => 
                                <div 
                                key={ship.id}
                                onDragStart={(e) => dragStartHandler(e,ship)}
                                onDragLeave={(e) => dragEndHandler(e)}
                                onDragEnd={(e) => dragEndHandler(e)}
                                onDragOver={(e) => dragOverHandler(e)}
                                onDrop={(e) => dropHandler(e, ship)}
                                draggable
                                className={ship.name}>
                                </div>
                            )}
                        </div>    
                    </div> 
                <div className="lobby-configuration lobby-row-container">
                    <div className="players-info">
                    </div>
                    <div className="buttons">
                        <button className="ready-button">Ready</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default LobbyPage;
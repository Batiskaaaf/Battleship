import React from 'react';
import styles from "./Grid.module.css"
import Cell from "../Cell"
import ShipsLayout from '../ShipsLayout';

const Grid = ({shiplist, setCoorsOfShip, ...props}) => {

    const cells = [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,];
    
    const dragStartHandler = (e,item) => {
        console.log("start", item);
    } 
    const dropHandler = (e,index) => {
        e.preventDefault();
        console.log(e);
        setCoorsOfShip({x: index%10, y:    Math.floor(index/10) });
        e.target.style.backgroundColor = "rgba(134, 145, 163, 0.5)";
    } 
    const dragEndHandler = (e) => {
        e.target.style.backgroundColor = "rgba(134, 145, 163, 0.5)";
        } 
    const dragOverHandler = (e) => {
        e.preventDefault();
        e.target.style.backgroundColor = "lightgray";
    } 
    console.log(shiplist);
  return (
    <div className="grid-container">
        <div {...props} className='grid'>
            {cells.map((c, index) => 
            <Cell
            x={index%10}
            y={Math.floor(index/10)}
            key={index}
            //onDragStart={(e) => dragStartHandler(e,index)}
            onDragLeave={(e) => dragEndHandler(e)}
            onDragEnd={(e) => dragEndHandler(e)}
            onDragOver={(e) => dragOverHandler(e)}
            onDrop={(e) => dropHandler(e, index)}
            //draggable
            >{index}</Cell>
            )}
        </div>
    </div>
  );
};

export default Grid;
import React from "react";

const ShipsLayout = ({shiplist, setCoorsOfShip, ...props}) =>{

    const dropHandler = (e, item) => {
        e.preventDefault();
        const x = Math.round((e.pageX - e.target.offsetLeft)/55);
        const y = Math.round((e.pageY - e.target.offsetTop)/55);  
        console.log(x,y);
        console.log(item);
        setCoorsOfShip({x,y});
        e.target.style.backgroundColor = "rgba(134, 145, 163, 0.5)";
    } 

    const dragOverHandler = (e) => {
        e.preventDefault();
        e.target.style.backgroundColor = "lightgray";
    } 

    return(
        <div className="ships-layout"
            onDrop={(e,item) => dropHandler(e,item)}
            onDragOver={(e) => dragOverHandler(e)}
        >
            {shiplist.map((ship) =>    
                ship.cell ? 
                    <div className='ship'
                    draggable
                    key={ship.index} 
                    style={{backgroundColor: ship.color, width: 53 * ship.length, height: 54, top:54 * ship.cell.y, left: 53 * ship.cell.x}}>

                    </div>
                    :
                    <></>
            )}
        </div>
    )
}

export default ShipsLayout
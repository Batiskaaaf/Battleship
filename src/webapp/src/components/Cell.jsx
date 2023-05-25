import React from "react";

const Cell = ({x,y,isShip, isDamaged, ...props}) =>{

    return(
        <div style={{width: 53, height: 54, top:54 * y, left: 53 * x}} {...props} className="cell">

        </div>
    );


}

export default Cell;
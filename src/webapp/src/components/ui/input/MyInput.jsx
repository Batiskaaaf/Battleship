import React, { Children } from "react";
import classes from "./MyInput.module.css"

const MyInput = (props) =>{
    return(
        <input placeholder="Username" className={classes.myInput}></input>
    )
}

export default MyInput;
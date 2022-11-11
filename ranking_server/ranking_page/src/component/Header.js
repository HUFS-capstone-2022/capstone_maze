import React from "react";
import { Link } from 'react-router-dom';
import '../css/Header.css'

function Header() {
    return(
        <div className="header">
            <Link className="link" to="/">
                <h1>Maze Ranking</h1>
            </Link>
        </div>
    )
}

export default Header;
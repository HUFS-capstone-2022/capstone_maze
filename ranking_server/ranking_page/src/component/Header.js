import React from "react";
import { Link } from 'react-router-dom';
import '../css/Header.css'

function Header() {
    return(
        <div>
            <Link className="link" to="/">
                <h1>Capstone Project</h1>
            </Link>
        </div>
    )
}

export default Header;
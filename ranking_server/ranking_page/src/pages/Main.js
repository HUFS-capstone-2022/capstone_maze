import React from 'react';
import Header from '../component/Header';
import { Link } from 'react-router-dom';
import '../css/Main.css';

function Main() {
    return (
        <div>
            <Header></Header>
            <Link className='check_rank' to="/Result">
                <div className='rank_text'>
                    랭킹 확인하기
                </div>
            </Link>
        </div>
    )
}


export default Main;
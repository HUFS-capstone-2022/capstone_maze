import React from 'react';
import Header from '../component/Header';
import { useNavigate } from 'react-router-dom';
import '../css/Main.css';

function Main() {
    const navigate = useNavigate();

    const move_true = () => {
        navigate('/Result', {
            state: {
                end_id : "true",
            }
        })
    }
    const move_norm = () => {
        navigate('/Result', {
            state: {
                end_id : "normal",
            }
        })
    }
    const move_bad = () => {
        navigate('/Result', {
            state: {
                end_id : "bad",
            }
        })
    }

    return (
        <div>
            <Header></Header>
            <div className='rank_text'>
                랭킹 확인하기
            </div>
            <div>
                <table className='rank_table'>
                    <tbody>
                        <td>
                            <div className='end_type' onClick={move_true}>True_ending</div>
                        </td>
                        <td>
                            <div className='end_type' onClick={move_norm}>Normal_ending</div>
                        </td>
                        <td>
                            <div className='end_type' onClick={move_bad}>Bad_ending</div>
                        </td>
                    </tbody>  
                </table>
            </div>
        </div>
    )
}


export default Main;
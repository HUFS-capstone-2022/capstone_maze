/* eslint-disable */
import { React, useEffect, useState } from "react";
import '../css/Ranking.css';
import axios from 'axios';
function Bad_end_Ranking() {
    const [completed, setCompleted] = useState(false);
    const [data, setData] = useState({ row : [] })
    const [lastData, setLastData] = useState({row : []});

    useEffect(() => {

        const rankingData = async () => {
            try {
                const infoRankData = await axios.get("http://localhost:4000/ranking", { params : { rankType : "Bad", PlayerId : 5 } });
                const testdata = JSON.parse(infoRankData.data)
                console.log(testdata[0])
                setData(testdata)
                if (testdata.success === false) {
                    alert("존재하지 않는 유저입니다.");
                    return;
                }
                return testdata;
            } catch (err) {
                console.log(err);
                alert("서버 접속 오류");
                return;
            }
        }
        rankingData();
        setCompleted(true);
        console.log(completed);

    }, [])

    return(
        <div>
            <div className="ending_title">Bad Ending Rank</div>
            <table className="table">
                <thead className="thead">
                    <tr>
                        <td>Rank</td><td>Name</td><td>Clear Time</td>
                    </tr>
                </thead>        
                {data[0] === undefined ? (
                <div>waiting</div>
                ) : (
                <tbody className="tbody">
                    <tr>
                        <td>{data[0].id}</td><td>{data[0].name}</td><td>{data[0].clear_time}</td>
                    </tr>
                </tbody>
                )}
            </table>
        </div>
    )
}

export default Bad_end_Ranking;
import { React, useEffect } from "react";
import { useParams } from 'react-router-dom';
import '../css/Ranking.css';
import axios from 'axios';

function True_end_Ranking() {
    const params = useParams();

    useEffect(() => {

        const rankingData = async () => {
            try {
                const infoRankData = await axios.get("/ranking", { params : "true" });
                const infoRank = infoRankData.data;
                console.log(infoRank);
                if (infoRank.success === false) {
                    alert("존재하지 않는 유저입니다.");
                    return;
                }


            } catch (err) {
                console.log(err);
                alert("서버 접속 오류");
                return;
            }
        }
        rankingData();
    })

    return(
        <div>
            <div className="ending_title">True Ending Rank</div>
            <table className="table">
                <thead className="thead">
                    <tr>
                        <td>Rank</td><td>Name</td><td>Clear Time</td>
                    </tr>
                </thead>
                <tbody className="tbody">
                    <tr>
                        <td>1</td><td>hello</td><td>1:22:4</td>
                    </tr>
                </tbody>
            </table>
        </div>
    )
}

export default True_end_Ranking;
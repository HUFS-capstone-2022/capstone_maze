import React from "react";
import '../css/Ranking.css'

function Bad_end_Ranking() {
    return(
        <div>
            <div className="ending_title">Bad Ending Rank</div>
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

export default Bad_end_Ranking;
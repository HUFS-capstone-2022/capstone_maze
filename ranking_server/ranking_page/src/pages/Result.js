import React from "react";
import Header from "../component/Header";
import TrueRanking from "../component/True_end_Ranking";
import NormalRanking from "../component/Normal_end_Ranking";
import BadRanking from "../component/Bad_end_Ranking";
import NotFound from "../pages/NotFound";
import '../css/Result.css';
import { useLocation } from "react-router-dom";

function Result() {
    const location = useLocation();

    const end_type = location.state.end_id;

    return(
        <div>
            <Header></Header>
            <div className="rank_page">
                Ranking Page
            </div>
            {
                end_type === "true"
                ? <TrueRanking />
                : end_type === "normal"
                    ? <NormalRanking />
                    : end_type === "bad"
                        ? <BadRanking />
                        : <NotFound />
            }
        </div>
    )
}

export default Result;
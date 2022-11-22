using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProtocolsCopy
{
    public class Packets
    {
        public class find_req
        {
            public string userId;
            public find_req(string userId)
            {
                this.userId = userId;
            }
        }

        // : 역직렬화
        // : 서버 -> 클라이언트
        public class find_res
        {
            public List<endType> True;
            public List<endType> Normal;
            public List<endType> Bad;
        }

        public class endType
        {
            public List<info_userData> rank1;
            public List<info_userData> rank2;
            public List<info_userData> rank3;
            public List<info_userData> rank4;
            public List<info_userData> rank5;
            public List<info_userData> rank6;
            public List<info_userData> rank7;
            public List<info_userData> rank8;

        }

        // : 역직렬화 대상
        public class info_userData
        {
            public int id;
            public string name;
            public DateTime clear_time;
            public int clear_type;
        }
    }
}
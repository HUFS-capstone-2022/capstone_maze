using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Protocols
{
    public class Packets
    {
        public class find_req
        {
            public int userId;
            public string clearType;
            public find_req(int userId, string clearType)
            {
                this.userId = userId;
                this.clearType = clearType;
            }
        }

        // : 역직렬화
        // : 서버 -> 클라이언트
        public class find_res
        {
            public List<info_userData> userData;
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
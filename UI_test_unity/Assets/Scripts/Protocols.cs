using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Protocols
{
    public class Packets
    {
        public class find_req
        {
            public string userName;
            public find_req(string userName)
            {
                this.userName = userName;
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
            public string userID;
            public string userName;
            public string userClearType;
            public string userClearTime;
        }
    }
}
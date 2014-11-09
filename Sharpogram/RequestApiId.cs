using System;
using System.Text;
using System.IO;
using Telegram.API;
using Telegram.MTProto;
using Telegram.TLCore;
using NUnit.Framework;
using System.Net.Sockets;
using System.Windows;

namespace Sharpogram
{
    class RequestApiId
    {
        /*
-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6
lyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daS
an9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTw
Efzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+
8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3n
Slv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB
-----END RSA PUBLIC KEY-----
        */
        // 19114
        // 1e489fd15dcff313e5b3e7a08e8fc791
        ConnectionInfo[] connections;
        public void run() {
            connections = new ConnectionInfo[]{
                new ConnectionInfo(1, 0, "149.154.167.40", 443)
            };

            ApiState apiState = new ApiState(connections);
            doReqCode();

//            TLSaveDeveloperInfo info = new TLSaveDeveloperInfo("egor-st-dev", "egor.st.dev@gmail.com", "+79241652563", 19, "Yakutsk");

        }
        private void doReqCode()
        {
            TLContext tlContext = new TLApiContext();
            TcpClient tcpClient = new TcpClient();
            tcpClient.ConnectAsync(connections[0].getAddress(), (int)connections[0].getPort());
            TLRequestAuthSendCode tlRequestAuthSendCode = new  TLRequestAuthSendCode("+79241652563", 
                                                    0, 19114, "1e489fd15dcff313e5b3e7a08e8fc791", "en");

            tlRequestAuthSendCode.serializeBody(new StreamWriter(tcpClient.GetStream()));
//            tlRequestAuthSendCode.deserializeBody(new BufferedStream(tcpClient.GetStream()), tlContext);

        }
        
    }
}

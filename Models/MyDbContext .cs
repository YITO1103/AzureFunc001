/*
using Entity;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;Ssl Mode=Require;");
        //=> optionsBuilder.UseNpgsql(@"Host=sever-pg-a.postgres.database.azure.com;Username=postgres;Password=miumiu@0816;Database=postgres;SSL Mode=Prefer;");
      //=> optionsBuilder.UseNpgsql  (@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;");
        => optionsBuilder.UseNpgsql  (@"Server=sever-pg-a.postgres.database.azure.com;Database=postgres;Port=5432;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;");




        //=> optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;");
}
*/
using Renci.SshNet;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.IO;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    private static SshClient _sshClient;

    static MyDbContext()
    {
        SetupSshTunnel();
    }


    private static string privateKey = @"
-----BEGIN RSA PRIVATE KEY-----
MIIG4wIBAAKCAYEAunM0eglTY/yCop8+OV5vnQ2i93fwcQxcp5pKIhAlZxML2PqO
W+/389vjgWn33huzAaN2XdffqEV1L7VHFUK3CsOMdWykLSfuQ7lpIG/9Wcmdm89E
JsJS2t1ivFpMcq56lvXSMOH5cZ7odAjvl+T4S6nXqMkhd0j2BcLr/A4WzQbFwGMW
bHSxRlLR/f8nAuTv7ooPNWVCnuNm+KyRgF7vfVd7dula6IGreWvs6XHXgwoOLRi1
glsM/tFZSVzC/sxzhszDCpyPzhOdWiAoKCXjHzz7j726J3GRSVW5ataYUsSX2ovT
zrrUOpsabxAa4NyjsvBW1LSgQnswjjHgiqmyiyaVXXiVffDiin1LX+SDIUif9yx/
6fYy6KqfFSEiWrRIwqdfq/CVV6/c6+BPhMFtwnAKHNhTF28lTFI51xQ6xfa+bXHc
H5uE0y5ENvllSAlT5civnrIlws0gtgw4lf+DQBqYzz/ZP6gowoPC0tmXCJIPr6Sg
Ts1LAaWq7uZ9QxnNAgMBAAECggGAcEvS322efCopxCiFIahvMPh1nvbuKih35bpX
zAxNerdN+3FtLJJrlMRrUhaw42VreyEouXy7iG3NFt7n4TY9aI4+mrrEZy4Vo1SY
rKDGxr1X3/AF7BI+NPQB88+vG6Na0nFcF3UC+BvthXWcWK/fnDK/YTlCnsWi5/Vu
jHEv6myZzjXf25Ks8t4O/BwhMu0QVWtxnYdPiMMN0dieCeMj+yolgokp57+xt3/5
QOEAHDyCLUcki06rlQ4h6L2l9DDOnE2Za4Ktvu1/+qPAyTpJNU4F/KTCGmKYTbNs
U+/KgiD+1wktuZq9pYdiwM5hqbfE/VSWzNNck/IAflG0JRyjzdARI5CdV0tZQ3cR
SjxqyG5aZCXb7TCu6OoGeV1k7a6c+S5VxcteX9tHjYf50YzonZLrfoeOHv3Sw8xd
FmTNUdwyEDGlNrNdpaJo+H/VmQfBzPTbEmz0n49eWVMUcFrzhCp6u227iKPwTL37
oK69QKcroP3HMohzcbpUqRRymHFBAoHBAOfqQP8bQQDH48WGV8gZizHmXfKJwrCN
nAmZyPwpfs3fw8MXmCHfwkQR1OjpLAeXM+gnS6t0mfiuVpKCS+Zroob6m8vLY1RL
748NjgPfhChUBVGbgL6L9NmWml44BGAwuflv6nELD3fhACStBxokkDt+dY5hYVdu
46Q2J4akIZqnlrFUwB/uInE5ISvUg9CO5mXbUd5erxd/fXzzEx4ILIP/zbmErQMn
gAzgwVVylzQAogW9LSBeMHFovjAVxxTdbwKBwQDN0DUXq+WsOV1hUHp5MUULLViJ
unXcjepZ6W3XnNFi/YT3i3JYBVx3zPrBtWSTKlx1N4gXO2XQFmU9di4Spftm73vh
XD/pqnIBCbQC//uEQk8wncKMW6LcYW9DmOoFmCOKkfOy2NYD9goRgKW/WVlcODBO
NhwmPZKwumsfjNGGW3p2dcwlSkGIdK3RFGTIH97JJT78+rHXLAedpFDtBbzZlpkH
kEVOqmuVr9GpID3je3QLYvySDiTf2ATmz7O11oMCgcBTEhrUBjwjfnY9A6Ef4N52
MlFGlkfxm9ffrIFMqcRtFBD4KdRplc/tOAHup88IrQV/y8uUD8EzTade9WMglz9x
YAU8W48p28VklXNgOckJ9Qaus6fLGTDMW+DRjPksR2fmTEtK0K5qv2KgwIXBvIUZ
enO7W3BVtDfAU1GXLeWHky4sOPJUvaUCr3cNTyMkKnum0oehwoKvRRB7GEqpwD3J
znAvWrHqZlS8yCkYZWJ50xw2OAwZAwQRK3asnLBh7esCgcBpsZsSZPy1zV/fMe0z
f9HtQ4RMdq1AbsEDG5WFPMtrArbeSYaXHWm3PFUqVXUo/oAs0i/Zfm9yxY2IWsCe
Yw8Qdbwwp6dK4HVbgxgm0j7gVQ1F8j6OxiCE/KSfGlBUPyVBbGKyXhjKP/g7tM1p
zwDNEy37fF5IZSaIC7Qnp7GSRjhFzYjhPZkZ8pGw5cA75eILek02rafW0I24r0G/
90pck7JS6AwvseU+IeSR7jTaNfQKRPNgLlNRgSZDQjcQEvECgcEAjd4qcp5cqBh6
gs+zGbKpdtdzUq35BEmywmApnf+3ope7t2J5Va7yHL+0oOyznQ2NRu+mZV+SOcF9
UCDJj22Noh33wk43SMKKmc+U0kj9FttoXM39aEEvyOshjRyKwGOR090EtYJNl0CF
6hUc6jydBQurBKcl3s+syL4UV2JwDBhc6bzXZ4f4/XTwXCGNsGcHcSclso2WJjAD
MARPFiS9Dp/Y9ayYlJn9ljbckWEJEcQlmKROkAI9TpG//l3rI4fa
-----END RSA PRIVATE KEY-----";

    private static void SetupSshTunnel()
    {
        var connectionInfo = new ConnectionInfo(
            //"sever-pg-a.postgres.database.azure.com",
            "20.89.44.142",
            "azureuser",
            //new PrivateKeyAuthenticationMethod("azureuser", new PrivateKeyFile("path-to-your-private-key"))
            new PrivateKeyAuthenticationMethod("azureuser", new PrivateKeyFile(new MemoryStream(System.Text.Encoding.ASCII.GetBytes(privateKey))))

        );


        _sshClient = new SshClient(connectionInfo);
        _sshClient.Connect();

        var portForwarded = new ForwardedPortLocal("127.0.0.1", 5433, "127.0.0.1", 5432);
        _sshClient.AddForwardedPort(portForwarded);
        portForwarded.Start();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Database=postgres;Port=5433;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;");
        => optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Database=;Port=5433;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;");
}

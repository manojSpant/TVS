using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Class Name  : TokenEntity. 
/// Description : This class use for Token entity.. 
/// Dependencies:
/// Created By  : Mindfire Solutions.
/// Created Date: 14 June 2018.
/// Modified Date/Desc: 
/// </summary>
///
namespace TimeValue.BusinessEntities.TimeValue.Auth
{
 
  public class TokenEntity
    {
        public long TokenId { get; set; }
        public long UserId { get; set; }
        public String AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

    }
}

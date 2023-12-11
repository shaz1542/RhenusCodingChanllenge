using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLuck.Domain.Entities;
public class Player : BaseAuditableEntity
{
    public string? Name { get; set; }
    public int BalancePoints { get; set; }

    public Player() => BalancePoints = 10000;

}

using System.Reflection.Metadata.Ecma335;

namespace Core.Domain;


public enum OrderStatus
{
    Created,
    Purchased, 
    Completed,
    Cancelled,
}
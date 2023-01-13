using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public Reservation(ReservationId id,
        int guestCount, 
        ReservationStatus reservationStatus, 
        GuestId guestId, 
        BillId billId,  
        DateTime createdDateTime, 
        DateTime updatedDateTime)
        : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        GuestId guestId,
        BillId  billId
    )
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            ReservationStatus.Reserved,
            guestId,
            billId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
    
    public int GuestCount{get;}
    public ReservationStatus ReservationStatus{get;}
    public GuestId GuestId{get;}
    public BillId BillId {get;}
    public DateTime? ArrivalDateTime{get;} = null;
    public DateTime CreatedDateTime{get;}
    public DateTime UpdatedDateTime{get;}
}
public enum ReservationStatus
{
    PendingGuestConfirmation, Reserved, Cancelled
}
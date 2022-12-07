import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { BookingsService } from './bookings.service'

@Component({
  selector: 'bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnDestroy {  
  public bookings: any = [];
  private subs: Subscription | null = null;
  public columns: string[] = ['name', 'bookingDate', 'flexibility', 'vehicleSize', 'contactNumber', 'email'];
  
  constructor(
    private _bookingService: BookingsService
  ) { 
    this._bookingService.getBookings().subscribe({
      next: data => {
        this.bookings = data;
      },
      error: error => {
        console.log(error)
      }
    })
  }

  ngOnDestroy(){
    if (this.subs) {
      this.subs.unsubscribe();
      this.subs = null;
    }
  }
}

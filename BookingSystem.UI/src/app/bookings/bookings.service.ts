
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../../url/url'
import { IBooking } from '../interfaces';

@Injectable()
export class BookingsService {
    private url!: string;

    constructor(private _http: HttpClient) {
        this.url = apiUrl.url
    };

    getBookings() {
        return this._http.get<IBooking[]>(this.url + '/api/bookings/list');
    }
}

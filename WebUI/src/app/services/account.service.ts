import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountHeader } from '../models/account.model';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  private baseUrl = 'http://localhost:5081/api/Account';

  constructor(private http: HttpClient) {}

  // 1. Fetch all accounts
  getAllAccounts(): Observable<AccountHeader[]> {
    return this.http.get<AccountHeader[]>(this.baseUrl);
  }

  // 2. Fetch single account by ID
  //    If your API returns an account plus its invoices, you won’t need a second call to get invoices separately.
  getAccount(id: number): Observable<AccountHeader> {
    return this.http.get<AccountHeader>(`${this.baseUrl}/id?id=${id}`);
  }
}
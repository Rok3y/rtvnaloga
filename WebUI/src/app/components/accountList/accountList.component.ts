import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountHeader } from '../../models/account.model';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-accountList',
  templateUrl: './accountList.component.html',
  styleUrl: './accountList.component.css',
  standalone: false
})

export class AccountsListComponent {
  accounts: AccountHeader[] = [];
  selectedAccountId: number | null = null;

  sortColumn: string = 'number';
  sortDirection: 'asc' | 'desc' = 'asc'; 

  constructor(
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadAccounts();
  }

  loadAccounts(): void {
    this.accountService.getAllAccounts().subscribe({
      next: (data) => {
        console.log("data", data); // data is an array of AccountHeader objects
        this.accounts = data;
      },
      error: (err) => {
        console.error('Error fetching accounts', err);
      }
    });
  }

  onSelectAccount(accountId: number): void {
    // Navigate to the detail route
    this.selectedAccountId = accountId;

    console.log("accountId started", accountId);
    this.router.navigate(['/accounts', accountId]);
  }

  // Called when a column header is clicked
  sortBy(column: string) {
    if (this.sortColumn === column) {
      // If clicking the same column, toggle direction
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      // If clicking a new column, sort ascending by default
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.sortAccounts();
  }

  // Reorder the `accounts` array based on the current sortColumn and sortDirection
  sortAccounts() {
    this.accounts.sort((a, b) => {
      // Convert the values based on the active column
      let valA: any;
      let valB: any;

      switch (this.sortColumn) {
        case 'number':
          valA = a.number;
          valB = b.number;
          break;
        case 'dateTime':
          // Convert date strings to numeric timestamps for comparison
          valA = new Date(a.dateTime).getTime();
          valB = new Date(b.dateTime).getTime();
          break;
        case 'recipientName':
          valA = a.recipientName.toLowerCase();
          valB = b.recipientName.toLowerCase();
          break;
        default:
          return 0; // No sorting if we somehow get an unknown column
      }

      // Ascending / descending comparison
      if (valA < valB) {
        return this.sortDirection === 'asc' ? -1 : 1;
      }
      if (valA > valB) {
        return this.sortDirection === 'asc' ? 1 : -1;
      }
      return 0;
    });
  }

}

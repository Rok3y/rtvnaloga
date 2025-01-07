import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})


export class AppComponent {
  title = 'WebUI';

  constructor(
    private router: Router
  ) {}
}

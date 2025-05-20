import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'FitSeek';
  http = inject(HttpClient);
  users: any;

  ngOnInit(): void {
    this.http.get("https://localhost:7164/api/users").subscribe({
      next: result => this.users = result,
      error: error => console.error(error),
      complete: () => console.log("Operation completed."),
    });
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title: string = 'SECCL App';
  portfolio: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('http://localhost:5001/portfolio').subscribe({
      next: (response) => this.portfolio = response,
      error: (err) => console.log(err),
      complete: () => console.log('Request has completed')
    });

  }
}

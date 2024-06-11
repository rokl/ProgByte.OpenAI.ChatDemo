import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public messages: string[] = [];
  public message: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit() {

  }

  processMessage() {
    this.messages.push(this.message);
    this.postMessage();
    this.message = "";
  }

  postMessage() {
    this.http.post<string>('/OpenAI/postMessage', { messages: this.messages }).subscribe(
      (result) => {
        console.log(result);
        this.messages.push(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'progbyte.openai.chatdemo.client';
}

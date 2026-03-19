import { Component } from '@angular/core';
import { Footer } from "./footer/footer";
import { Header } from './header/header';
import { Main } from './main/main';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [Footer,Header,Main, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {

  
}

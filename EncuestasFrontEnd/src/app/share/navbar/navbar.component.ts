import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  hasSession = environment.hasSession;

  constructor(){}

  ngOnInit(): void{
  
  }
}

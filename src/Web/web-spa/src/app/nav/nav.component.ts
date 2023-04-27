import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  items: MenuItem[];

  ngOnInit() {
    this.items = [
      {
        label: 'Courses',
        icon: 'pi pi-fw pi-list',
        routerLink: ['/courses']
      },
      {
        label: 'Quizzes',
        icon: 'pi pi-fw pi-question',
        routerLink: ['/quizzes']
      }
    ];
  }
}

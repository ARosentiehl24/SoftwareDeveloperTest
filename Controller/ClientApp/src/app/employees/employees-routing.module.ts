import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './pages/list/list.component';
import { EmployeeComponent } from './pages/employee/employee.component';

const routes: Routes = [
  {
    component: ListComponent,
    path: '',
  },
  {
    component: EmployeeComponent,
    path: ':id',
  },
];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class EmployeesRoutingModule {}

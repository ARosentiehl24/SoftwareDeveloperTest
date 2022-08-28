import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { EmployeesRoutingModule } from './employees-routing.module';
import { FormsModule } from '@angular/forms';
import { EmployeesTableComponent } from './components/employees-table/employees-table.component';
import { EmployeeInfoComponent } from './components/employee-info/employee-info.component';

@NgModule({
  declarations: [
    ListComponent,
    EmployeeComponent,
    EmployeesTableComponent,
    EmployeeInfoComponent,
  ],
  imports: [CommonModule, FormsModule, EmployeesRoutingModule],
})
export class EmployeesModule {}

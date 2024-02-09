import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Survey } from '../../core/interfaces/survey';
import { SurveyServiceService } from '../../core/serivices/survey.service';

@Component({
  selector: 'app-surveys',
  templateUrl: './surveys.component.html',
  styleUrl: './surveys.component.scss'
})
export class SurveysComponent implements OnInit{
  displayedColumns: string[] = [
    'id',
    'name',
    'description',
    'registrationDate',
    'startDate',
    'endDate'
  ];
  dataSource!: MatTableDataSource<Survey>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  display: string = 'none';
  constructor(private surveyService: SurveyServiceService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.surveyService.getSurveys().subscribe((response) => {
      const surveysArray = Array.isArray(response.model)
        ? response.model
        : [response.model];

      this.dataSource = new MatTableDataSource(surveysArray);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openModal(row: Survey) {
    this.display = 'block';
  }
  onCloseHandled() {
    this.display = 'none';
  }
  
}

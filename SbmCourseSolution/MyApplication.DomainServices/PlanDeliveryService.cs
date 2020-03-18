using MyApplication.DomainInterfaces;
using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.DomainModel.PlannedDeliveryAggregate;
using MySoftwareCompany.DDD;
using System;

namespace MyApplication.DomainServices
{
    public class PlanDeliveryService
    {

        //A Domain Service 
        //   - contains business logic which needs multiple domain entities.
        //   - is injected with need repositories
        //   - is injected with a unit of work

        private IUnitOfWork _unitOfWork;
        private IDeliveryRepository _deliveryRepository;
        private IPlannedDeliveryRepository _plannedDeliveryRepository;

        public PlanDeliveryService(
            IUnitOfWork unitOfWork,
            IDeliveryRepository deliveryRepository, 
            IPlannedDeliveryRepository plannedDeliveryRepository)
        {
            _unitOfWork = unitOfWork;
            _deliveryRepository = deliveryRepository;
            _plannedDeliveryRepository = plannedDeliveryRepository;
        }

        //Methods in Domain Services are
        //   - verbs known in the ubiquitous language
        //   - have simple (primitive) attributes, no domain entities
        public bool PlanDelivery(string deliveryId, string arrivalTimeForeseen, int deliveryOrder)
        {
            try
            {
                //Start a Unit Of Work
                _unitOfWork.Start();

                //Get the delivery to be planned.
                var deliveryToBePlanned = _deliveryRepository.GetById(deliveryId);

                //Set delivery as planned
                deliveryToBePlanned.IsPlanned = true;
                _deliveryRepository.Update(deliveryToBePlanned);

                //Create a planned delivery with foreseen arrivaltime and delivery order
                var plannedDelivery = PlannedDelivery.Create(deliveryToBePlanned.Id, arrivalTimeForeseen, deliveryOrder);
                _plannedDeliveryRepository.Add(plannedDelivery);

                //Commit the Unit Of Work
                _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                //Log your exception
                //Commit the Unit Of Work
                _unitOfWork.RollBack();
                return false;
            }

        }
    }
}

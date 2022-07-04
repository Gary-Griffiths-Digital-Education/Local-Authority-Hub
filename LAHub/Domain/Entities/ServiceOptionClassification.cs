﻿using LAHub.Domain.Common;

namespace LAHub.Domain.Entities;

public class ServiceOptionClassification : BaseEntity
{
    public ServiceOptionClassification(
        Guid serviceOptionTypeId,
        Guid linkId,
        Guid classificationId
    )
    {
        Id = Guid.NewGuid();
        ServiceOptionTypeId = serviceOptionTypeId;
        LinkId = linkId;
        ClassificationId = classificationId;
    }

    public Guid ServiceOptionTypeId { get; }

    public Guid LinkId { get; }

    public Guid ClassificationId { get; }
}

